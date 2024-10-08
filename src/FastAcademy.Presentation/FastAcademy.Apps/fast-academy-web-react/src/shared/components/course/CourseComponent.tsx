import { Rate } from 'antd'
import './CourseComponent.css'

interface Props {
  onClick?: () => void
}

export default function CourseComponent(props: Props) {
  const { onClick } = props

  return (
    <div onClick={onClick} className='flex flex-col border rounded-lg'>
      {/* Thumbnail */}
      <img
        className='w-full h-auto rounded-t-lg cursor-pointer'
        loading='lazy'
        src='https://www.codewithantonio.com/_next/image?url=https%3A%2F%2Futfs.io%2Ff%2F3fd4e9e6-8489-4005-a6a7-29f0338745b1-jbkgcj.jpg&w=1920&q=75'
      />
      {/* Course */}
      <div className='bg-white border rounded-b-lg p-3'>
        <div className='font-semibold text-[14px]'>Full Stack Spotify Clone</div>
        <div className='text-gray-600'>toilavinh</div>
        {/* Rate */}
        <div className='text-[13px] mt-1'>
          <span className='font-semibold'>4,6&nbsp;</span>
          <Rate allowHalf disabled defaultValue={4.5} className='course-rate text-[13px]' />
          <span>&nbsp;(10.000)</span>
        </div>
        {/* Price */}
        <div className='text-[14px]'>
          <span className='font-semibold'>₫ 299.000</span>
          <span className='font-light line-through ml-2'>₫ 1.499.000</span>
        </div>
      </div>
    </div>
  )
}
