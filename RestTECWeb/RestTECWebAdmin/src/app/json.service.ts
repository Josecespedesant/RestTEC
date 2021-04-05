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
  urlMenu='http://localhost:'+this.apiPort+'/api/plato/menu';
  urlVer='http://localhost:'+this.apiPort+'/api/login/verificar';
  urlTopVend='http://localhost:'+this.apiPort+'/api/plato/top_vendidos';
  urlTopGan='http://localhost:'+this.apiPort+'/api/plato/top_ganancias';
  urlTopFed='http://localhost:'+this.apiPort+'/api/plato/top_feedback';
  urlTopOrd='http://localhost:'+this.apiPort+'/api/plato/top_ordenes';
  

  constructor(private http: HttpClient) { }
   //Metodo get implementa .get de httpclient
  getJson(ruta:number){
    if(ruta==1){
      return this.http.get(this.urlMenu,this.header)
    }if(ruta==2){
      return this.http.get(this.urlTopVend,this.header)
    }if(ruta==3){
      return this.http.get(this.urlTopGan,this.header)
    }if(ruta==4){
      return this.http.get(this.urlTopFed,this.header)
    }if(ruta==5){
      return this.http.get(this.urlTopOrd,this.header)
    }
    else{
      console.log(ruta)
      return this.http.get(this.urlMenu,this.header)
    }

      
  }
  //Metodo post implementa .post de httpclient
  postJson(ruta:number,obj:any){
    if(ruta==1){
      return this.http.post(this.urlVer,obj,this.header);
    }else{
      return this.http.post(this.urlVer,obj,this.header);
    }
}
}
