import type { FC } from 'react'

export const Navbar: FC = () => {
	return (
		<nav>
			<div className="navbar bg-base-100 shadow-sm">
				<div className="navbar-start">
					<a className="btn btn-ghost border-0 text-xl" href="/">
						Todo List
					</a>
				</div>

				<div className="navbar-end">
					<a className="btn">Log out</a>
				</div>
			</div>
		</nav>
	)
}
