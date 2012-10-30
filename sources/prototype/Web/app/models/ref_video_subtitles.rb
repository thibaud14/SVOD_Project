class RefVideoSubtitles < ActiveRecord::Base
  attr_accessible :name


  has_many :video_subtitles
  has_many :video, :through => :video_subtitles
end
