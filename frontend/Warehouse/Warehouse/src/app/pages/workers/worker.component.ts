import { Component, OnInit } from "@angular/core";
import { WorkerService } from "src/app/services/workers.service";
import { Worker } from "../../models/worker.model";

@Component({
  selector: 'app-department',
  templateUrl: './worker.component.html',
  styleUrls: ['./worker.component.scss']
})
export class WorkersComponent implements OnInit {
  
  workers: Worker[] = [];

  constructor(
    private readonly workersService: WorkerService
  ){}

  ngOnInit(): void {
    this.loadDepartments();
  }
  
  onEditClick(workerId: number){

  }

  onDeleteClick(workerId: number){
    this.workersService.deleteWorker(workerId)
    .subscribe(() =>
    (this.workers = this.workers.filter(
      (p) => p.id != workerId
    ))
  );
  }

  private loadDepartments(){
    this.workersService
      .getWorkers()
      .subscribe((workers)=> (this.workers = workers));
  }
}