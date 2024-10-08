import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import Cart from '../home/cart/Cart'
import CourseDetail from '../home/course-detail/CourseDetail'
import Courses from '../home/courses/Courses'
import Home from '../home/Home'
import Learning from '../learning/Learning'

const router = createBrowserRouter([
  {
    path: '/',
    element: <Home />,
    children: [
      {
        index: true,
        element: <Courses />
      },
      {
        path: '/courses/:courseId',
        element: <CourseDetail />
      },
      {
        path: '/cart',
        element: <Cart />
      }
    ]
  },
  {
    path: '/learning/:courseId',
    element: <Learning />
  }
])

export default function AppRouter() {
  return <RouterProvider router={router} />
}
