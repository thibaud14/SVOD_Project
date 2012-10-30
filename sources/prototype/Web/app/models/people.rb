class People < ActiveRecord::Base
  attr_accessible :birthdate, :firstname, :name

  has_many :video_people
  has_many :video, :through => :video_people
end
