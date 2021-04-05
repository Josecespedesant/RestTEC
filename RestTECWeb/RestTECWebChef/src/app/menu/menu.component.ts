import { Component } from '@angular/core';
import { JsonService } from "../json.service"

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
  pedidos : Array<any>= [];
  //el contructor de platos utilizado para pedir la lista de pedidos guardarla en una variable y si presentarlo en la interfaz
  constructor(public json:JsonService) {
    this.json.postJson(2,"chef1").subscribe((res:any) => {
      console.log(res);
      this.pedidos=res;
    });
  }

  refresh(){
    window.location.reload();
  }

}
