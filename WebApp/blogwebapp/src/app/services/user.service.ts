import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  _fb: FormBuilder
  formModel: any
  readonly BaseURI = environment.apiuUrl
  constructor(private fb: FormBuilder, private http: HttpClient) {
    this._fb = fb;

    this.formModel = this._fb.group({
      UserName: ['', Validators.required],
      Email: ['', Validators.email],
      FullName: [''],
      Passwords: this._fb.group({
        Password: ['', [Validators.required, Validators.minLength(4)]],
        ConfirmPassword: ['', Validators.required]
      })

    });
  }

  register() {
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI + '/Register', body);
  }

  login(formData: any) {
    return this.http.post(this.BaseURI + '/Login', formData);
  }

  getUserProfile() {
    return this.http.get(this.BaseURI + '/UserProfile');
  }
}
