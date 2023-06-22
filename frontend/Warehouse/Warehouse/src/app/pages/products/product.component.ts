import { Component, OnInit } from "@angular/core";
import { Product } from "src/app/models/product.model";
import { ProductService } from "src/app/services/products.service";

@Component({
  selector: 'app-department',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductsComponent implements OnInit {

  products: Product[] = [];

  constructor(
    private readonly productsService: ProductService
  ) { }

  ngOnInit(): void {
    this.loadProducts();
  }

  onEditClick(id: number){

  }

  onDeleteClick(id: number){
    this.productsService.deleteProduct(id)
      .subscribe(() =>
      (this.products = this.products.filter(
        (p) => p.id != id
      )));
  }

  private loadProducts() {
    this.productsService
      .getProducts()
      .subscribe((products) => (this.products = products));
  }
}