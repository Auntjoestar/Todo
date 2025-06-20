import { apiUrl } from './asp'

export const loginQuery = async (
	email: string,
	password: string
): Promise<{ success: boolean }> => {
	const url = `${apiUrl}/login?useCookies=true`
	const response = await fetch(url, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json',
		},
		credentials: 'include',
		body: JSON.stringify({
			email: email,
			password: password,
		}),
	})

	if (response.status != 200) {
		const errorText = await response.text()
		throw new Error(`Request failed with status: ${response.status} - ${errorText}`)
	}

	return { success: true }
}

export const logoutQuery = async (): Promise<{ success: boolean; message?: string }> => {
	const url = `${apiUrl}/logout`
	const response = await fetch(url, {
		method: 'GET',
		credentials: 'include',
	})

	if (response.status == 401) {
		return { success: false, message: 'User is not authorized.' }
	}

	if (response.status != 200) {
		const errorText = await response.text()
		throw new Error(`Request failed with status: ${response.status} - ${errorText}`)
	}

	return { success: true }
}

interface userIdentity {
	isAuthenticated: boolean
	userName: string | null
}

export const isUserAuthQuery = async (): Promise<userIdentity> => {
	const url = `${apiUrl}/me`
	const response = await fetch(url, {
		method: 'GET',
		headers: {
			'Content-Type': 'application/json',
		},
		credentials: 'include',
	})

	const userIdentity: userIdentity = await response.json()

	if (response.status == 401) {
		return userIdentity
	}

	if (response.status != 200) {
		const errorText = await response.text()
		throw new Error(`Request failed with status: ${response.status} - ${errorText}`)
	}

	return userIdentity
}
