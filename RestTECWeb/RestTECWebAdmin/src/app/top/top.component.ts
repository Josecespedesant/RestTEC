import { Component } from '@angular/core';
import { JsonService } from "../json.service";

@Component({
  selector: 'app-top',
  templateUrl: './top.component.html',
  styleUrls: ['./top.component.css']
})
export class TopComponent { 
  platos : Array<any>= [];
  ruta=0;
//Metodo utilizado para actualizar la lista en los tops llama al metodo on init para actualizar la lista
  aRuta(rut:number){
    this.ruta=rut;
    console.log(this.ruta)
    this.OnInit();
  }
  
  constructor(public json:JsonService) {}
  //metodo onInit utilizado para ejecutar el get al api y obtener la lista
   OnInit(){
    this.json.getJson(this.ruta).subscribe((res:any) => {
      console.log(res);
      this.platos=res;
    }); 
   }

}

