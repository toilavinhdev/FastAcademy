import { CheckOutlined } from '@ant-design/icons'
import { Button, Collapse, Rate } from 'antd'
import { useState } from 'react'

const CheckLineComponent = () => {
  return (
    <div className='mb-3'>
      <div className='flex gap-x-2'>
        <CheckOutlined className='text-blue-600' />
        <div>Hoàn thành khóa học Javascript cơ bản tại F8 hoặc đã nắm chắc Javascript cơ bản</div>
      </div>
    </div>
  )
}

const CourseLecturesComponent = () => {
  return <p>CourseLecturesComponent</p>
}

const CourseCurriculumComponent = () => {
  return (
    <div className='mt-4'>
      <Collapse
        items={Array.from({ length: 6 }).map((_, idx) => {
          return {
            key: idx + 1,
            label: 'This is panel header 1',
            children: <CourseLecturesComponent />
          }
        })}
        defaultActiveKey={[1]}
      />
    </div>
  )
}

export default function CourseDetail() {
  const [isCollapseExpandAll, setIsCollapseExpandAll] = useState<boolean>(false)

  return (
    <div className='grid grid-cols-12 gap-x-6'>
      <section className='col-span-8 bg-white rounded-lg border p-6'>
        {/* Introdution */}
        <div>
          <div className='text-[30px] font-bold'>Lập Trình JavaScript Nâng Cao</div>
          <div className='mt-4'>
            Build a Full Stack Spotify Clone with Next 13.4, React, Tailwind, Supabase, PostgreSQL, and Stripe in 2023!
            In this comprehensive tutorial, you'll learn how to develop a complete music streaming application from
            scratch, replicating the popular features and functionalities of Spotify.
          </div>
          {/* Rate */}
          <div className='flex gap-x-2 items-center text-[15px] leading-[15px] mt-4'>
            <div className='font-semibold'>4,6</div>
            <Rate allowHalf disabled defaultValue={5} className='text-[16px]' />
            <div className='font-semibold text-blue-600 underline'>(10.000 xếp hạng)</div>
            <div>&bull;</div>
            <div>35.239 học viên</div>
          </div>
        </div>
        {/* Content */}
        <div className='mt-6'>
          <div className='text-[20px] font-bold'>Bạn sẽ học được gì</div>
          <div className='grid grid-cols-2 gap-x-10 mt-2'>
            {Array.from({ length: 7 }).map((_, idx) => (
              <CheckLineComponent key={idx} />
            ))}
          </div>
        </div>
        {/* Curriculum */}
        <div className='mt-4'>
          <div className='text-[20px] font-bold'>Nội dung khóa học</div>
          <div className='flex mt-2'>
            <div className='flex gap-x-2'>
              <div>
                <span className='font-semibold'>13</span> chương
              </div>
              <div>&bull;</div>
              <div>
                <span className='font-semibold'>80</span> bài giảng
              </div>
              <div>&bull;</div>
              <div>
                Thời lượng <span className='font-semibold'>09 giờ 00 phút</span>
              </div>
            </div>
            <div className='font-semibold text-blue-600 ml-auto cursor-pointer'>
              {!isCollapseExpandAll ? 'Mở rộng tất cả' : 'Thu nhỏ tất cả'}
            </div>
          </div>
          <CourseCurriculumComponent />
        </div>
        {/* Prerequisites */}
        <div className='mt-6'>
          <div className='text-[20px] font-bold'>Yêu cầu</div>
          <div className='mt-2'>
            {Array.from({ length: 6 }).map((_, idx) => (
              <CheckLineComponent key={idx} />
            ))}
          </div>
        </div>
      </section>
      <section className='col-span-4 rounded-lg'>
        <div>
          <img
            src='https://www.codewithantonio.com/_next/image?url=https%3A%2F%2Futfs.io%2Ff%2F3fd4e9e6-8489-4005-a6a7-29f0338745b1-jbkgcj.jpg&w=1920&q=75'
            className='rounded-t-lg shadow-xl'
          />
          <div className='bg-white rounded-b-lg p-4'>
            <div>Price</div>
            <Button size='large' type='primary'>
              Enroll
            </Button>
            <div>Level senior</div>
            <div>16 hours</div>
            <div>80 lectures</div>
            <div>Learn anytime, learn anywhere</div>
          </div>
        </div>
      </section>
    </div>
  )
}
