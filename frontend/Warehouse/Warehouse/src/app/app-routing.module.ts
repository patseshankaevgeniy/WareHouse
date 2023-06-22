import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { DepartmentComponent } from "./pages/department/department.component";
import { AppLayoutComponent } from "./pages/app-layout.component";
import { ProductsComponent } from "./pages/products/product.component";
import { WorkersComponent } from "./pages/workers/worker.component";

export const basePath = '';
export const departmentsPath = 'departments';
export const workersPath = 'workers'
export const productsPath = 'products';

const routes: Routes = [
  {
    path: basePath, 
    component: AppLayoutComponent, 
    children: [
      {
        path: departmentsPath,
        component: DepartmentComponent
      },
      {
        path: workersPath,
        component: WorkersComponent
      },
      {
        path: productsPath,
        component: ProductsComponent
      }
  ]}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
