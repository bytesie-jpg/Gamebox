import { post } from "../fetch-wrapper"
import { User } from "../types/user"

export const createUser = async (user: User) => {
    return post('ddd', user)
}