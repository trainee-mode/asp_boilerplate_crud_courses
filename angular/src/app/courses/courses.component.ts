import { Component, Injector, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  CourseServiceProxy,
  CourseDto,
} from '@shared/service-proxies/service-proxies';
import { CreateCourseDialogComponent } from './create-course/create-course-dialog.component';
import { EditCourseDialogComponent } from './edit-course/edit-course-dialog.component';

@Component({
  // selector: 'app-courses',
  templateUrl: './courses.component.html',
  animations: [appModuleAnimation()]
})
export class CoursesComponent implements OnInit{
  courses: CourseDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _coursesService: CourseServiceProxy,
    private _modalService: BsModalService
  ){}

  ngOnInit(): void {
    this.list();  
  }

  list(): void {
    this._coursesService.getAllCourses()
      .subscribe({
        next: (result) => {
          this.courses = result; 
          abp.notify.success('Courses loaded successfully!');
        },
        error: (error) => {
          abp.notify.error('Failed to load courses: ' + error.message);
        }
      });
  }

  getCourseThroughTitle(title: string): void {
    this._coursesService.getCourseByTitle(title).subscribe({
      next: (result) => {
        this.courses = Array.isArray(result) ? result : [result]; 
      },
      error: (error) => {
        console.error('Error fetching courses:', error);
        this.courses = []; 
      }
    });
  }

  delete(course: CourseDto): void {
    abp.message.confirm(( course.title),
      undefined,
      (result: boolean) => {
        if (result) {
          this._coursesService
            .deleteCourse(course.id)
            .pipe(
              finalize(() => {
                abp.notify.success('SuccessfullyDeleted');
                window.location.reload()
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createCourse(): void {
    this.showCreateOrEditCourseDialog();
  }

  reloadPage(): void {
    window.location.reload();
  }

  editCourse(course: CourseDto): void {
    this.showCreateOrEditCourseDialog(course.id);
  }

  showCreateOrEditCourseDialog(id?: string): void {
    let createOrEditCourseDialog: BsModalRef;
    if (!id) {
      createOrEditCourseDialog = this._modalService.show(
        CreateCourseDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } 
    else {
      createOrEditCourseDialog = this._modalService.show(
        EditCourseDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditCourseDialog.content.onSave.subscribe(() => {
      window.location.reload()
    });
  }
}
