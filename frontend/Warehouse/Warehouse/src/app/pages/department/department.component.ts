import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/models/department.model';
import { DepartmentService } from 'src/app/services/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.scss']
})
export class DepartmentComponent implements OnInit {

  public departmentName: string = "";
  departments: Department[] = [];
  public departmentId: number = 0;
  public canAdd: boolean = false

  constructor(
    private readonly departmentService: DepartmentService
  ){}

  ngOnInit(): void {
    this.loadDepartments();
  }
 
  addNewDepartment(){
    
  }

  onEditClick(departmentId: number) {
    
  }

  onDeleteClick(departmentId: number) {
    this.departmentService.deleteDepartment(departmentId)
    .subscribe(() =>
      (this.departments = this.departments.filter(
        (p) => p.id != departmentId
      ))
    );
  }

  onChangeClick(){
    if(this.canAdd){
      this.canAdd = false;
    }
    else{
      this.canAdd = true;
    }
  }

  private loadDepartments(){
    this.departmentService
      .getDepartments()
      .subscribe((departments)=> (this.departments = departments));
  }
}
