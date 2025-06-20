import React, {
	StrictMode,
	useEffect,
	useState,
	type ChangeEvent,
	type FC,
	type FormEvent,
	type HtmlHTMLAttributes,
	type SyntheticEvent,
} from 'react'
import { loginQuery } from '../../lib/asp/auth'

export const LoginForm: FC = () => {
	const [email, setEmail] = useState('')
	const [password, setPassword] = useState('')

	const handleEmailChange = (e: ChangeEvent<HTMLInputElement>) => {
		setEmail(e.target.value)
	}

	const handlePasswordChange = (e: ChangeEvent<HTMLInputElement>) => {
		setPassword(e.target.value)
	}

	const handleOnSubmit = (e: FormEvent) => {
		e.preventDefault()
		loginQuery(email, password).then((result) => console.log(result))
		setEmail('')
		setPassword('')
	}

	return (
		<StrictMode>
			<form method="post" onSubmit={handleOnSubmit} id="loginForm">
				<fieldset className="fieldset">
					<legend className="fieldset-legend">Email</legend>
					<input
						type="email"
						className="input"
						placeholder="example@example.com"
						value={email}
						onChange={handleEmailChange}
						required
					/>
				</fieldset>
				<fieldset className="fieldset">
					<legend className="fieldset-legend">Password</legend>
					<input
						type="password"
						className="input"
						placeholder="password"
						value={password}
						onChange={handlePasswordChange}
						required
					/>
				</fieldset>
			</form>
			<button className="btn btn-neutral" type="submit" form="loginForm">
				Login
			</button>
		</StrictMode>
	)
}
