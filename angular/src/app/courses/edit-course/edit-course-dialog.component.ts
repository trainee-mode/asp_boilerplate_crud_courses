import { CourseDto } from './../../../shared/service-proxies/service-proxies';
import {
    Component,
    Injector,
    OnInit,
    EventEmitter,
    Output,
  } from '@angular/core';
  import { BsModalRef } from 'ngx-bootstrap/modal';
  import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
  import { AppComponentBase } from '@shared/app-component-base';
  import {
    CourseServiceProxy
    
  } from '@shared/service-proxies/service-proxies';
  
  @Component({
    templateUrl: 'edit-course-dialog.component.html'
  })
  export class EditCourseDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    id: string;
    course = new CourseDto();
  
    @Output() onSave = new EventEmitter<any>();
  
    constructor(
      injector: Injector,
      private _courseService: CourseServiceProxy,
      public bsModalRef: BsModalRef,
    ) {
      super(injector);
    }
  
    ngOnInit(): void {
      if (this.id) {
        this._courseService.getCourseById(this.id).subscribe({
          next: (result) => {
            this.course = result;
          },
          error: (error) => {
            this.notify.error('Error fetching course: ' + error.message);
          }
        });
      }
        
    }
  
    save(): void {
      this.saving = true;
  
      const course = new CourseDto();
      course.init(this.course);
  
      this._courseService.updateCourse(course).subscribe(
        () => {
          this.notify.info('SavedSuccessfully');
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        (error) => {
          this.saving = false;
          this.notify.error('Failed to save the course: ' + error.message);
        }
      );
    }
  }
  