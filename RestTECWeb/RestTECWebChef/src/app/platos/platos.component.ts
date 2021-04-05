import { Component} from '@angular/core';
import { JsonService } from "../json.service"

@Component({
  selector: 'app-platos',
  templateUrl: './platos.component.html',
  styleUrls: ['./platos.component.css']
})
export class PlatosComponent {
  pedidos : Array<any>= [];
  //el contructor de platos utilizado para pedir la lista de pedidos guardarla en una variable y si presentarlo en la interfaz
  constructor(public json:JsonService) { 
    this.json.getJson(1).subscribe((res:any) => {
      console.log(res);
      this.pedidos=res;
    });
  }
refresh(){
  window.location.reload();
}

}
