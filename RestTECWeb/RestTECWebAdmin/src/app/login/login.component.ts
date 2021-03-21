import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { NgForm } from '@angular/forms';
import { JsonService } from "../json.service"

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(public json:JsonService, private router: Router, private location: Location) { 
    this.json.getJson().subscribe((res:any) => {

      console.log(res);
    }); 

  }
  
  public isError = false

  public OnInit(){}

  public onLogin(form: NgForm){
    if (form.valid) {
          console.log(form.value)
          this.router.navigate(['/home']);
          this.isError = false;
    } else {
      this.onIsError();
    }
    
  }
  onIsError(): void {
    this.isError = true;
    setTimeout(() => {
      this.isError = false;
    }, 4000);
  }

}
