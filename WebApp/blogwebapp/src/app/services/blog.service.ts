
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  http: any;
  readonly BaseURI = environment.apiuUrl
  constructor() { }

  saveProduct(Product: any) {
    return this.http.post(this.BaseURI + '/Blog', Product);
  }
}
