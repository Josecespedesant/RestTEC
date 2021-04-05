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
  }
  
  public isError = false

  public OnInit(){}
//metodo onLogin verifica si el form del html es valida, envia el username y password al metodo post y espera respuesta del API
  public onLogin(form: NgForm){
    if (form.valid) {
      this.json.postJson(1,form.value).subscribe((res:any) => {
        console.log(res);
        if(res=="Ok"){
          this.router.navigate(['/home']);
          this.isError = false;
        }else{
          this.isError = true;
        }
      }); 
          console.log(form.value)
          
          
          
    } else {
      this.onIsError();
    }
    
  }
  //metodo onIsError si la form no es valida presenta un component que indica error
  onIsError(): void {
    this.isError = true;
    setTimeout(() => {
      this.isError = false;
    }, 4000);
  }

}
