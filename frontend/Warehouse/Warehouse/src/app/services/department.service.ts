import { Observable } from "rxjs";
import { map } from "rxjs/operators"
import { DepartmentDto, IDepartmentDto, WareHouseAPIClient } from "../clients/warehouse-api.client";
import { Department } from "../models/department.model";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  constructor(
    private warehouseAPIClient: WareHouseAPIClient
  ) { }

  getDepartments(): Observable<Department[]> {
    return this.warehouseAPIClient
      .getDepartments()
      .pipe(map(({ result }) => result.map(department => this.mapToModel(department))));
  }

  getDepartment(id: number): Observable<Department> {
    return this.warehouseAPIClient
      .getDepartment(id)
      .pipe(map(({ result }) => this.mapToModel(result)));
  }

  createDepartment(department: Department): Observable<Department> {
    return this.warehouseAPIClient
      .createDepartment(new DepartmentDto(this.mapToDto(department)))
      .pipe(map(({ result }) => this.mapToModel(result)));
  }

  deleteDepartment(id: number): Observable<void> {
    return this.warehouseAPIClient
      .deleteDepartment(id)
      .pipe(map(({ }) => { }));
  }

  private mapToModel(dto: IDepartmentDto): Department {
    return new Department(
      dto.id!,
      dto.name!,
      dto.products!,
      dto.workers!
    );
  }

  private mapToDto(model: Department): IDepartmentDto {
    return {
      id: model.id!,
      name: model.name,
      products: model.products,
      workers: model.workers
    }
  }
}