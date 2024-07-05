import { Component, Injector, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  QuizServiceProxy,
  QuizDto,
} from '@shared/service-proxies/service-proxies';

@Component({
  // selector: 'app-quizzes',
  templateUrl: './quizzes.component.html',
  animations: [appModuleAnimation()]
})
export class QuizzesComponent implements OnInit {
  quizzes: QuizDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _quizzesService: QuizServiceProxy,
    private _modalService: BsModalService
  ){}

  ngOnInit(): void {
    this.list();  
  }

  list(): void {
    this._quizzesService.getAllQuizzes()
      .subscribe({
        next: (result) => {
          this.quizzes = result; 
          abp.notify.success('Quizzes loaded successfully!');
        },
        error: (error) => {
          abp.notify.error('Failed to load quizzes: ' + error.message);
        }
      });
  }

  delete(quiz: QuizDto): void {
    abp.message.confirm(( quiz.title),
      undefined,
      (result: boolean) => {
        if (result) {
          this._quizzesService
            .deleteQuiz(quiz.id)
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

  createQuiz(): void {
    this.showCreateOrEditQuizDialog();
  }

  reloadPage(): void {
    window.location.reload();
  }

  editCourse(quiz: QuizDto): void {
    this.showCreateOrEditQuizDialog(quiz.id);
  }

  showCreateOrEditQuizDialog(id?: number): void {
    let createOrEditQuizDialog: BsModalRef;
    // createOrEditQuizDialog = this._modalService.show(
    //   EditQuizDialogComponent,
    //   {
    //     class: 'modal-lg',
    //     initialState: {
    //       id: id,
    //     },
    //   }
    // );
    createOrEditQuizDialog.content.onSave.subscribe(() => {
      window.location.reload()
    });
  }

}
