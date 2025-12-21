import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';
import { MainLayoutComponent } from './shared/components/main-layout/main-layout.component';
import { StudentDashboardComponent } from './shared/components/student-dashboard/student-dashboard.component';
import { ChatComponent } from './modules/chat/chat/chat.component';
import { EditComponent } from './modules/students/edit/edit.component';
import { MyenrollmentsComponent } from './modules/enrollments/myenrollments/myenrollments.component';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    canActivateChild: [authGuard],
    children: [
      {
        path: 'students',
        loadChildren: () =>
          import('./modules/students/students.module').then((m) => m.studentRoutes),
         data: {"roles": ["Admin"]}
         
      },
      {
        path: 'courses',
        loadChildren: () => import('./modules/courses/courses.module').then((m) => m.CoursesRoutes),
      },
      {
        path: 'classes',
        loadChildren: () => import('./modules/classes/classes.module').then((m) => m.ClassesRoutes),
      },
      {
        path: 'chat',
        loadChildren: () => import('./modules/chat/chat.module') .then(m => m.ChatModule)
      },
      {
        path: '',
        loadChildren: () => import('./modules/students/students.module').then((m) => m.studentRoutes),
      }
    ],
  },
    
  {
    path: 'Dashboard',
    component: StudentDashboardComponent,
    canActivate: [authGuard],
    data: { role: 'Student' },
    children: [
      { path: 'chat', component: ChatComponent },
      {path:'myenrollments' , component:MyenrollmentsComponent}
    ]
  },
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule),
  },
  { path: '', redirectTo: 'auth/login', pathMatch: 'full' },
  { path: '**', redirectTo: 'auth/login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
