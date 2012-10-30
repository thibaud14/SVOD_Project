class RefVideoLangue < ActiveRecord::Base
  attr_accessible :name

  has_many :video_langue
  has_many :video, :through => :video_langue

end
