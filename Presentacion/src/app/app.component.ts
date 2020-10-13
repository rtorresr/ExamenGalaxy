import { Component, OnInit, ViewChild } from '@angular/core';
import {OpcionService} from 'src/app/services/opcion.service';
import { OpcionModel } from './models/opcion.model';
import { PaginacionModel } from './models/paginacion.model';
import {MatDialog, MatDialogConfig, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {ModalComponent} from 'src/app/component/modal/modal.component';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Presentacion';
  displayedColumns: string[] = ['codigo', 'nombre', 'url', 'icono', 'accion'];
  dataSource: MatTableDataSource<OpcionModel>;

  opciones: OpcionModel[] = [];
  pag: PaginacionModel = {
    Filtro: '',
    NroPag: 0,
    RegPorPag: 10
  };

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    public opcionServices: OpcionService,
    public dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.cargarOpciones(this.pag);
  }

  cargarOpciones(paginacion: PaginacionModel) {
    this.opcionServices.cargarOpciones(paginacion)
      .subscribe((res: any) => {
        console.log(res);
        this.pag.NroRegTotal = res.totalReg;
        this.opciones = res.listaOpcion;
        this.dataSource = new MatTableDataSource<OpcionModel>(res.listaOpcion);
        this.dataSource.paginator = this.paginator;
      });
  }

  editar(element: OpcionModel) {
    const dialogRef = this.dialog.open(ModalComponent, {
      data: element
    });

    dialogRef.afterClosed().subscribe(() => {
      this.cargarOpciones(this.pag);
      this.snackBar.open('Editado correctamente', 'OK', {
        duration: 1000,
        horizontalPosition: 'center',
        verticalPosition: 'top',
      });
    });
  }

  insertar() {
    const opcionEmpty: OpcionModel = {
      codigo: 0,
      nombre: '',
      url: '',
      icono: ''
    };

    this.dialog.open(ModalComponent, {
      data: opcionEmpty
    }).afterClosed().subscribe((res) => {
      this.cargarOpciones(this.pag);
      console.log(this.pag);
    });

    // dialogo.afterClosed().subscribe(() => {
    //   console.log(this.pag);
    //   this.cargarOpciones(this.pag);
    //   this.snackBar.open('Agregado correctamente', 'OK', {
    //     duration: 1000,
    //     horizontalPosition: 'center',
    //     verticalPosition: 'top',
    //   });
    // });

  }

  eliminar(element: OpcionModel) {
    const confirmation = confirm('¿Estás seguro que desea eliminar?');

    if (confirmation) {
      this.opcionServices.eliminarOpcion(element)
      .subscribe((msg) => {
        this.cargarOpciones(this.pag);
        this.snackBar.open('Eliminado correctamente', 'OK', {
          duration: 1000,
          horizontalPosition: 'center',
          verticalPosition: 'top',
        });
      });
    }
  }
}
