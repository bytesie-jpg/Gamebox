

export function useRecentlyRatedHook() {
    return useQuery({
        queryFn: () => {
            return createUser(newUser)
        }
    })
}