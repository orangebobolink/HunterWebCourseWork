import {IUser} from "../IUser";

export interface IAuthRepsponse {
    accessToken: string
    refreshToken: string
    email: string
    roles: string[]
}