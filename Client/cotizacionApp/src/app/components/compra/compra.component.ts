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
  transaccionRealizada: Transaccion;
  message: string;
  errorMessage: string;
  loading: boolean = false;
  constructor(private cotizacionService: CotizacionService) { }

  ngOnInit() {
  }

  comprar() {
    if (!this.transaccion.usuarioId || !this.transaccion.moneda || !this.transaccion.monto) {
      this.errorMessage = 'Por favor ingrese todos los campos';
      return;
    }

    this.transaccionRealizada = null;
    this.transaccion.createdBy = this.transaccion.usuarioId;
    this.transaccion.updatedBy = this.transaccion.usuarioId;
    this.transaccion.createdOn = new Date();
    this.transaccion.updatedOn = new Date();
    this.loading = true;

    this.cotizacionService.comprar(this.transaccion).subscribe((result: Response) => {
      if (result.success) {
        this.transaccion = new Transaccion();
        this.transaccionRealizada = result.data;
        this.errorMessage = null;
        this.message = result.message;
        this.loading = false;
      }
      else {
        this.message = null;
        this.transaccionRealizada = null;
        this.errorMessage = result.message;
        this.loading = false;
      }
    });
  }
}
