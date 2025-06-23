import { StrictMode, useEffect, useState, type ChangeEvent, type FC, type FormEvent } from 'react'
import { TodoForm } from './TodoForm'
import { TaskList } from './TaskList'
import { getActivitiesQuery } from '../../../lib/asp/activities'

interface Task {
	id: number
	name: string
	description: string | null
	status: string
}

export const TodoList: FC = () => {
	const [nextId, setNextId] = useState(0)

	const [tasks, setTasks] = useState<Task[]>([])

	useEffect(() => {
		getActivitiesQuery()
			.then((activities) => activities.map((activity: Omit<Task, 'id'>) => handleAddTask(activity)))
			.catch((e) => alert(e))
	}, [])

	const handleAddTask = (newTaskData: Omit<Task, 'id'>) => {
		const newTask: Task = {
			id: nextId,
			...newTaskData,
		}

		setTasks((prevTask) => [...prevTask, newTask])
		setNextId((prevId) => prevId + 1)
		return nextId
	}

	const handleFailAddTask = (id: number) => {
		setTasks((prevTask) => prevTask.filter((task) => task.id !== id))
		setNextId((prevId) => prevId - 1)
	}

	return (
		<StrictMode>
			<TodoForm onAddTask={handleAddTask} onFailAddTask={handleFailAddTask} />
			<TaskList tasks={tasks} />
		</StrictMode>
	)
}
