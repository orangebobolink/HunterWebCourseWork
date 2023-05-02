import {IUser} from "../IUser";

export interface AuthRepsponse {
    accessToken: string
    refreshToken: string
    user: IUser
}