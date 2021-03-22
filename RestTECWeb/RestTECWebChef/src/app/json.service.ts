import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class JsonService {
  url='';
  constructor(private http: HttpClient) { }
  
  getJson(){
      return this.http.get(this.url)
  }
  postJson(obj:any){
    return this.http.post(this.url,obj);
}
}
