import { useEffect, useState, type FC } from 'react'
import { useAuth } from './hooks/useAuth'
import { logoutQuery } from '../../lib/asp/auth'

export const Navbar: FC = () => {
	const { isAuthenticated, user } = useAuth()

	useEffect(() => {
		if (isAuthenticated === false) {
			window.location.href = '/login'
		}
	}, [])

	const handleLogOutClick = (e: React.MouseEvent<HTMLAnchorElement>) => {
		e.preventDefault()
		logoutQuery().then((result) => {
			if (result.success) {
				window.location.href = '/login'
			}
		})
	}

	return (
		<nav>
			<div className="navbar bg-base-100 shadow-sm">
				<div className="navbar-start">
					<a className="btn btn-ghost border-0 text-xl" href="/">
						Todo List
					</a>
				</div>
				{isAuthenticated ? (
					<div className="navbar-end gap-5">
						<label className="label">{user}</label>
						<a className="btn" onClick={handleLogOutClick}>
							Log out
						</a>
					</div>
				) : (
					<div className="navbar-end">
						<a className="btn" href="login">
							Login
						</a>
					</div>
				)}
			</div>
		</nav>
	)
}
