import { User } from './user.model';

export class UserGroup {
    constructor(
        public from: number,
        public to: number,
        UserModels: User
    ) {}
}