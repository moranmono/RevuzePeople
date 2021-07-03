import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { UserGroupComponent } from './user-group/user-group.component';
import { UserListComponent } from './user-group/user-list/user-list.component';
import { UserItemComponent } from './user-group/user-item/user-item.component';
import { UserDetailsComponent } from './user-group/user-details/user-details.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    UserGroupComponent,
    UserListComponent,
    UserItemComponent,
    UserDetailsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/user-group/0', pathMatch: 'full' },
      {
        path: 'user-group/:groupId', component: UserGroupComponent,
        children: [{
          path: 'user-details/:userId', component: UserDetailsComponent
        }]
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
