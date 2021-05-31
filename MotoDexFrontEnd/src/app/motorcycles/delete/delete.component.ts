import { Component, OnInit } from '@angular/core';
import { IMotorcycle, MotorcyclesService } from 'src/app/services/motorcycles.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  motorcycles: IMotorcycle[] = [];

  constructor(private _motoService: MotorcyclesService) { }

  ngOnInit(): void {
    this.GetData();
  }

  async GetData(){
    try {
      this.motorcycles = await this._motoService.GetJsonMotorcycles();
    } catch (error) {
      console.log(error)
    }
  }

  DeleteMoto(moto: IMotorcycle){
    console.log(moto.id)
    this._motoService.DeleteMotorcycleById(moto.id);
  }

}
