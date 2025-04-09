import { useMutation } from '@tanstack/react-query'
import { User } from '../types/user'
import { createUser } from '../api/user-api'

export function useCreateUserHook() {
    return useMutation({
        mutationFn: (newUser: User) => {
           return createUser(newUser)
        }
    })
}