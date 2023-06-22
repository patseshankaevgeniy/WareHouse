import { Component } from '@angular/core';
import { Department } from './models/department.model';
import { DepartmentService } from './services/department.service';

@Component({
  selector: 'app-root',
  template: `<router-outlet></router-outlet>`
})
export class AppComponent {

  departments: Department[] = [];

  constructor(
    private readonly departmentService: DepartmentService
  ){}

  ngOninit(): void{
    this.departmentService.getDepartments().subscribe((departments)=> (this.departments = departments));
  }
}
