import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MotorcyclesService {

  private _deleteSuccessful$: Subject<boolean> = new Subject();

  get deleteSuccessful$(): Observable<boolean> {
    return this._deleteSuccessful$.asObservable();
} 

  motorcycles: IMotorcycle[] = [];
  selectedMotorcycle: any;

  private _motoDexAddress = "https://localhost:44346/api/v1/";

  constructor(private _http: HttpClient) { }

  public PostObject(body: any, type: string){
    const headers = new HttpHeaders()
    .append(
      'Content-Type',
      'application/json'
    );
    return this._http.post<any>(this._motoDexAddress + type, body, {
      headers: headers
    }).subscribe((res) => console.log(res));
  }

  public GetJsonMotorcycles(){
    return this._http.get<IMotorcycle[]>(this._motoDexAddress + "motorcycles").toPromise();
  }

  public GetJsonMotorcycleByModel(model: string){
    return this._http.get<IMotorcycle[]>(this._motoDexAddress + "motorcycles" + "?model=" + model).toPromise();
  }

  public GetJsonMotorcycleById(id: number){
    return this._http.get<IMotorcycle>(this._motoDexAddress + "motorcycles/" + id).toPromise();
  }

  public DeleteMotorcycleById(id: number){
    return this._http.delete(this._motoDexAddress + "motorcycles/" + id).subscribe({
      next: data => {
          console.log("Delete Succesfull.");
          this._deleteSuccessful$.next(true);
      },
      error: error => {
          console.error('There was an error!', error);
      }
  });
  }

  // motoChange: Subject<IMotorcycle> = new Subject<IMotorcycle>();

}

export interface IMake {
    id: number;
    name: string;
    summary: string;
    motorcycles: any[];
}

export interface IEngine {
    id: number;
    engineType: string;
    engineConfiguration: string;
    capacity: number;
    maxPower: number;
    maxTorque: number;
    cooling: string;
    inductionType: string;
    sparkPlug: string;
}

export interface IFrontTyre {
    id: number;
    make: string;
    model: string;
    tyreWidth: number;
    heightAspect: number;
    rimSize: number;
    motorcycleFrontTyres: any[];
    motorcycleRearTyres?: any;
}

export interface IMotorcycleFrontTyre {
    motorcycleId: number;
    frontTyreId: number;
    frontTyre: IFrontTyre;
}

export interface IRearTyre {
    id: number;
    make: string;
    model: string;
    tyreWidth: number;
    heightAspect: number;
    rimSize: number;
    motorcycleFrontTyres?: any;
    motorcycleRearTyres: any[];
}

export interface IMotorcycleRearTyre {
    motorcycleId: number;
    rearTyreId: number;
    rearTyre: IRearTyre;
}

export interface IFrontBreakPads {
    id: number;
    padType: string;
    make: string;
    model: string;
}

export interface IRearBreakPads {
    id: number;
    padType: string;
    make: string;
    model: string;
}

export interface IMotorcycle {
    id: number;
    makeId: number;
    make: IMake;
    model: string;
    engineId: number;
    engine: IEngine;
    finalDrive: string;
    motorcycleFrontTyres: IMotorcycleFrontTyre[];
    motorcycleRearTyres: IMotorcycleRearTyre[];
    frontBreakPadsId: number;
    frontBreakPads: IFrontBreakPads;
    rearBreakPadsId: number;
    rearBreakPads: IRearBreakPads;
}


