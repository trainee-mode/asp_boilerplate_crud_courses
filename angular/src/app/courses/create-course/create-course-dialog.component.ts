import {
    Component,
    Injector,
    OnInit,
    EventEmitter,
    Output,
  } from '@angular/core';
  import { BsModalRef } from 'ngx-bootstrap/modal';
  import { AppComponentBase } from '@shared/app-component-base';
  import {
    CreateCourseDto,
    CourseDto,
    CourseServiceProxy
  } from '@shared/service-proxies/service-proxies';
  import { forEach as _forEach, map as _map } from 'lodash-es';
  
  @Component({
    templateUrl: 'create-course-dialog.component.html'
  })
  export class CreateCourseDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    course = new CourseDto();
  
    @Output() onSave = new EventEmitter<any>();
  
    constructor(
      injector: Injector,
      private _courseService: CourseServiceProxy,
      public bsModalRef: BsModalRef
    ) {
      super(injector);
    }
  
    ngOnInit(): void {
      this._courseService
    }
  
     
    save(): void {
      this.saving = true;
  
      const course = new CreateCourseDto();
      course.init(this.course);
  
      this._courseService
        .createCourse(course)
        .subscribe(
          () => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.bsModalRef.hide();
            this.onSave.emit();
          },
          () => {
            this.saving = false;
          }
        );
    }
  }
  