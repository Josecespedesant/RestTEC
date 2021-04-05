import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  ruta=0;
  constructor(private router: Router) { }
//navbar top metodos para redirigir al usuario cuando hacen click en los tops
  top1(){
    this.ruta=2
    this.router.navigate(['/top']);
  }
  top2(){
    this.ruta=3
    this.router.navigate(['/top']);
  }
  top3(){
    this.ruta=4
    this.router.navigate(['/top']);
  }
  top4(){
    this.ruta=5
    this.router.navigate(['/top']);
  }

}
