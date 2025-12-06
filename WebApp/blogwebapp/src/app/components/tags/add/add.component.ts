import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray, ValidationErrors, AbstractControl } from '@angular/forms';
import { BlogsService } from '../../../services/blog.service';

@Component({
  selector: 'app-add',
  standalone: false,
  templateUrl: './add.component.html',
  styleUrl: './add.component.css'
})
export class AddComponent {
  productForm!: FormGroup;
  public loadContent: boolean = false;
  constructor(private fb: FormBuilder, private _productsservice: ProductsService) { }

  ngOnInit() {

    this.setForm();
    
  }
  public setForm() {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
    });
    this.loadContent = true;

  }


  onSubmit() {
    debugger;
    console.log(this.productForm.valid);
    if (this.productForm.valid) {

        this._productsservice.saveProduct(this.productForm.value).subscribe(
          response => {
            console.log('POST request successful', response);
          },
          error => {
            console.error('Error during POST request', error);
          }
        );;
        // Handle form submission
      
    }
    else {
      console.log(this.productForm.controls);
      const invalid = [];
      const controls = this.productForm.controls;
      for (const name in controls) {
        if (controls[name].invalid) {
          invalid.push(name);
        }
      }
      console.log(invalid);
    }
  }
}
