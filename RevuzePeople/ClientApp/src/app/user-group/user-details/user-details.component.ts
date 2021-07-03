import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserGroupService } from 'src/app/shared/user-group.service';
import { User } from 'src/app/shared/user.model';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit, OnDestroy {
  private userId: number;
  private groupId: number;
  subscription: Subscription;
  user: User;
  constructor(private route: ActivatedRoute,
    private userGroupService: UserGroupService) { }

  ngOnInit() {
    this.subscription = this.userGroupService.groupIdSub
      .subscribe((res) => {
        this.groupId = res;
      });
    this.route.params
      .subscribe((params) => {
        this.userId = +params['userId'];
        this.userGroupService.getUserGroups()
          .subscribe((res) => {
            if (res) {
              this.user = res[this.groupId].userModels[this.userId];
            }
          });
      });

  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
