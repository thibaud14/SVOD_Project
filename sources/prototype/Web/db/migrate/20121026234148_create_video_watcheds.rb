class CreateVideoWatcheds < ActiveRecord::Migration
  def change
    create_table :video_watcheds do |t|

      t.timestamps
    end
  end
end
