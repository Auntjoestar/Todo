import { useEffect, useState } from 'react'
import { isUserAuthQuery } from '../../../lib/asp/auth'

export const useAuth = () => {
	const [isAuthenticated, setIsAuthenticated] = useState<boolean | null>(null)
	const [user, setUser] = useState<string | null>(null)

	useEffect(() => {
		isUserAuthQuery().then((status) => {
			if (!status.isAuthenticated) {
				setIsAuthenticated(false)
				setUser(null)
				return
			}

			setIsAuthenticated(true), setUser(status.userName)
		})
	}, [])

	return { isAuthenticated, user }
}
