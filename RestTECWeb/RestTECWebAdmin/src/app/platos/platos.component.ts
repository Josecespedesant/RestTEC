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
  public isError = false
  constructor(public json:JsonService, private router: Router, private location: Location) { }

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
