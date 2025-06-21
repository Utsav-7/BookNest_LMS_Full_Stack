import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { deactivateGuard } from '../../guards/deactivate.guard';

const routes: Routes = [
    {
        path: 'login',
        canDeactivate: [deactivateGuard],
        component: LoginComponent
    },
    {
        path: 'register',
        canDeactivate: [deactivateGuard],
        component: RegisterComponent
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AuthRoutingModule { }