import { Component, OnInit } from '@angular/core';
import { Transaccion } from './../../classes/Transaccion';
import { CotizacionService } from 'src/app/services/cotizacion.service';
import { Response } from 'src/app/classes/Response';

@Component({
  selector: 'app-compra',
  templateUrl: './compra.component.html',
  styleUrls: ['./compra.component.css']
})
export class CompraComponent implements OnInit {
  transaccion: Transaccion = new Transaccion();
  message: string;
  errorMessage: string;
  constructor(private cotizacionService: CotizacionService) { }

  ngOnInit() {
  }

  comprar() {
    if (!this.transaccion.usuarioId || !this.transaccion.moneda || !this.transaccion.monto) {
      this.errorMessage = 'Please fill all fields';
      return;
    }

    this.cotizacionService.comprar(this.transaccion).subscribe((result: Response) => {
      if (result.success) {
        this.transaccion = new Transaccion();
        this.message = result.message;
      }
      else {
        this.errorMessage = result.message;
      }
    });
  }
}
