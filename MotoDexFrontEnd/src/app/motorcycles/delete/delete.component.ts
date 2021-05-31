import { Component, OnInit } from '@angular/core';
import { Subject, Subscription } from 'rxjs';
import { IMotorcycle, MotorcyclesService } from 'src/app/services/motorcycles.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  motorcycles: IMotorcycle[] = [];
  deleteOperationSuccessfulSubscription = new Subscription;

  constructor(private _motoService: MotorcyclesService) {  }

  ngOnInit(): void {
    this.GetData();
    this.deleteOperationSuccessfulSubscription = this._motoService.deleteSuccessful$.subscribe(isSuccessful => {
        if (isSuccessful === true) { 
          this.GetData(); 
        } else {
            console.log("Couldn't delete.")
        }
    });
  }

  ngOnDestroy() {
    this.deleteOperationSuccessfulSubscription.unsubscribe();
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
