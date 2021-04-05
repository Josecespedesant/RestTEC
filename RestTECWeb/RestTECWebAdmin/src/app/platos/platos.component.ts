import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { NgForm } from '@angular/forms';
import { JsonService } from "../json.service"


@Component({
  selector: 'app-platos',
  templateUrl: './platos.component.html',
  styleUrls: ['./platos.component.css']
})
export class PlatosComponent {
  //el contructor de platos utilizado para pedir la lista de platos guardarla en una variable y si presentarlo en la interfaz
  public isError = false
  platos : Array<any>= [];
  constructor(public json:JsonService, private router: Router, private location: Location) {
    this.json.getJson(1).subscribe((res:any) => {
      console.log(res);
      this.platos=res;
    }); 
   }

  OnInit(): void {

  }

  public onSubmit(form: NgForm){
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

