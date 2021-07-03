import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserGroupService } from 'src/app/shared/user-group.service';
import { User } from 'src/app/shared/user.model';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  private groupId: number;
  userList: User[];
  constructor(private userGroupService: UserGroupService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params
      .subscribe((params) => {
        this.groupId = +params['groupId'];
        this.userGroupService.groupIdSub.next(this.groupId);
        this.userGroupService.getUserGroups()
          .subscribe(
            (res) => {
              if (res) {
                this.userList = res[this.groupId].userModels;
              }
            });
      });
  }
}
