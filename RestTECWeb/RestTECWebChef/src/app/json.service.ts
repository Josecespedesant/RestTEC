import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
//Servicio definido para implementar los POST Y GET del API
export class JsonService {

  apiPort="63256"
  header={headers:{'Access-Control-Allow-Origin':'http://localhost:4200','Access-Control-Allow-Methods': 'POST', "Access-Control-Allow-Headers": "Content-Type, Authorization"}}
  public ruta=0
  //Definicion de los URLS de conexion
  urlPed='http://localhost:'+this.apiPort+'/api/pedidos/listapedidos';
  urlVer='http://localhost:'+this.apiPort+'/api/login/verificar';
  urlMisPed='http://localhost:'+this.apiPort+'/api/plato/top_vendidos';
  urlTopGan='http://localhost:'+this.apiPort+'/api/plato/top_ganancias';
  urlTopFed='http://localhost:'+this.apiPort+'/api/plato/top_feedback';
  urlTopOrd='http://localhost:'+this.apiPort+'/api/plato/top_ordenes';
  constructor(private http: HttpClient) { }
  //Metodo get implementa .get de httpclient
  getJson(ruta:number){
    if(ruta==1){
      return this.http.get(this.urlPed,this.header)
    }
    else{
      console.log(ruta)
      return this.http.get(this.urlPed,this.header)
    }

      
  }
  //Metodo post implementa .post de httpclient
  postJson(ruta:number,obj:any){
    if(ruta==1){
      return this.http.post(this.urlVer,obj,this.header);
    }if(ruta==2){
      return this.http.post(this.urlVer,obj,this.header);
    }
    else{
      return this.http.post(this.urlVer,obj,this.header);
    }
}
}


