import { Observable } from "rxjs";
import { map } from "rxjs/operators"
import { IWorkerDto, WareHouseAPIClient, WorkerDto } from "../clients/warehouse-api.client";
import { Worker } from "../models/worker.model";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root',
})
export class WorkerService {
  constructor(
    private warehouseAPIClient: WareHouseAPIClient
  ) { }

  getWorkers(): Observable<Worker[]> {
    return this.warehouseAPIClient
      .getWorkers()
      .pipe(map(({ result }) => result.map(worker => this.mapToModel(worker))));
  }

  getWorker(id: number): Observable<Worker> {
    return this.warehouseAPIClient
      .getWorker(id)
      .pipe(map(({ result }) => this.mapToModel(result)));
  }

  createWorker(departmentId: number, worker: Worker): Observable<Worker> {
    return this.warehouseAPIClient
      .createWorker(departmentId, new WorkerDto(this.mapToDto(worker)))
      .pipe(map(({ result }) => this.mapToModel(result)));
  }

  deleteWorker(id: number): Observable<void> {
    return this.warehouseAPIClient
      .deleteWorker(id)
      .pipe(map(({ }) => { }));
  }

  private mapToModel(dto: IWorkerDto): Worker {
    return new Worker(
      dto.id!,
      dto.firstName!,
      dto.lastName!,
      dto.departments!
    );
  }

  private mapToDto(model: Worker): IWorkerDto {
    return {
      id: model.id,
      firstName: model.firstName,
      lastName: model.lastName,
      departments: model.departments
    }
  }
}