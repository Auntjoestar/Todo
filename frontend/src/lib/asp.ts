const apiUrl = import.meta.env.PUBLIC_API_URL

export const loginQuery = async (email: string, password: string) => {
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
