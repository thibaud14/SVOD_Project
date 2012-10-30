class VideoSubtitles < ActiveRecord::Base
  # attr_accessible :title, :body

  belongs_to :video
  belongs_to :ref_video_subtitles

end
