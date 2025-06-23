import { StrictMode, useState, type ChangeEvent, type FC, type FormEvent } from 'react'
import { postActivitiesQuery } from '../../../lib/asp/activities'

interface TodoFormProps {
	onAddTask: (newTask: { name: string; description: string | null; status: string }) => number
	onFailAddTask: (id: number) => void
}

export const TodoForm: FC<TodoFormProps> = ({ onAddTask, onFailAddTask }) => {
	const [name, setName] = useState('')

	const [description, setDescription] = useState<string | null>(null)

	const [status, setStatus] = useState('')

	const handleNameChange = (e: ChangeEvent<HTMLInputElement>) => {
		setName(e.target.value)
	}

	const handleDescriptionChange = (e: ChangeEvent<HTMLInputElement>) => {
		setDescription(e.target.value)
	}

	const handleStatusChange = (e: ChangeEvent<HTMLSelectElement>) => {
		setStatus(e.target.value)
	}

	const handleOnSubmit = (e: FormEvent) => {
		e.preventDefault()

		postActivitiesQuery(name, description, status).catch((e) => {
			alert(e)
			onFailAddTask(id)
		})

		const id = onAddTask({ name, description, status })

		setName('')
		setDescription('')
		setStatus('')
	}

	return (
		<StrictMode>
			<form id="todoForm" method="POST" onSubmit={handleOnSubmit}>
				<fieldset className="fieldset">
					<legend className="fieldset-legend">Name: </legend>
					<input
						type="text"
						className="input"
						placeholder="Name"
						value={name}
						onChange={handleNameChange}
						required
					/>
				</fieldset>
				<fieldset className="fieldset">
					<legend className="fieldset-legend">Description: </legend>
					<input
						type="text"
						className="input"
						placeholder="Name"
						value={description || ''}
						onChange={handleDescriptionChange}
					/>
					<label className="label">Optional</label>
				</fieldset>
				<fieldset className="fieldset">
					<legend className="fieldset-legend">Status</legend>
					<select className="select" value={status} onChange={handleStatusChange} required>
						<option disabled value="">
							Choose a status
						</option>
						<option>Active</option>
						<option>On Hold</option>
						<option>Done</option>
					</select>
				</fieldset>
			</form>
			<button className="btn btn-neutral" type="submit" form="todoForm">
				Add
			</button>
		</StrictMode>
	)
}
