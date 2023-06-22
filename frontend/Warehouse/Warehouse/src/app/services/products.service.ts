import { Observable  } from "rxjs";
import { map } from "rxjs/operators"
import { IProductDto, ProductDto, WareHouseAPIClient } from "../clients/warehouse-api.client";
import { Injectable } from "@angular/core";
import { Product } from "../models/product.model";

@Injectable({
  providedIn: 'root',
})
export class ProductService{
  constructor(
    private warehouseAPIClient: WareHouseAPIClient
  ){}

  getProducts(): Observable<Product[]> {
    return this.warehouseAPIClient
      .getProducts()
      .pipe(map(({ result }) => result.map(department => this.mapToModel(department))));
  }

  getProductsByDepartmentId(id: number): Observable<Product[]>{
    return this.warehouseAPIClient
      .getProductsByDepartmentId(id)
      .pipe(map(({ result }) => result.map(department => this.mapToModel(department))));
  }

  createProduct(product: Product): Observable<Product>{
    return this.warehouseAPIClient
      .createProduct(new ProductDto(this.mapToDto(product)))
      .pipe(map(({result}) => this.mapToModel(result)));
  }

  deleteProduct(id: number): Observable<void>{
    return this.warehouseAPIClient
      .deleteProduct(id)
      .pipe(map(({ }) => { }));
  }

  private mapToModel(dto: IProductDto): Product{
    return new Product(
      dto.id!,
      dto.name!,
      dto.departmentId!
    );
  }

  private mapToDto(model: Product): IProductDto{
    return {
      id: model.id,
      name: model.name,
      departmentId: model.departmentId
    }
  }
}